import React, { useEffect, useState } from 'react';
import { AuthProvider, User, useAuth } from 'oidc-react';
import Home from './Components/Home/Home';
import LoginForm from './Components/Login/LoginForm';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import AddProductForm from './Components/Catalog/AddProductForm'
import SignInOidc from './Components/SignInOidc';
import RoutesComponent from './Components/RoutesComponent';

const oidcConfig = {
  onSignIn: async (response: User | null) => {
    if (response && response.profile) {
      const newUrl = window.location.protocol + "//" + window.location.host + window.location.pathname;
      window.history.replaceState({}, document.title, newUrl);
    }
  },
  authority: 'https://localhost:5001',
  clientId: 'react_client',
  responseType: 'code',
  redirectUri: 'https://localhost:3000/signin-oidc',
  scope: 'openid profile React email CatalogAPI role',
  automaticSilentRenew: true,
  loadUserInfo: true,
};

function App() {
  const [user, setUser] = useState<{ name: string; sub: string; email: string } | null>(null);

  useEffect(() => {
    const savedUser = localStorage.getItem('user');
    if (savedUser) {
      setUser(JSON.parse(savedUser));
    }
  }, []);

  const handleLogin = (user: { name: string; sub: string; email: string }) => {
    setUser(user);
    localStorage.setItem('user', JSON.stringify(user));
  };

  const handleLogout = () => {
    setUser(null);
    localStorage.removeItem('user');
  };

  return (
    <AuthProvider {...oidcConfig}>
      <Router>
        <RoutesComponent user={user} onLogin={handleLogin} onLogout={handleLogout} />
      </Router>
    </AuthProvider>
  );
}

export default App;
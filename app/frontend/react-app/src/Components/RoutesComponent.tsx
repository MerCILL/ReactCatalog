import React from 'react';
import { Routes, Route } from 'react-router-dom';
import AddProductForm from './Catalog/AddProductForm';
import Home from './Home/Home';
import LoginForm from './Login/LoginForm';
import SignInOidc from './SignInOidc';

interface User {
    name: string;
    sub: string;
    email: string;
  }

  interface RoutesProps {
    user: User | null;
    onLogin: (user: User) => void;
    onLogout: () => void;
  }

  const RoutesComponent: React.FC<RoutesProps> = ({ user, onLogin, onLogout }) => (
    <Routes>
      <Route path='/' element={user ? <Home user={user} onLogout={onLogout} /> : <LoginForm onLogin={onLogin} />} />
      <Route path='/signin-oidc' element={<SignInOidc />} />
      <Route path='/add-product' element={<AddProductForm fetchCatalogProducts={function (): void {
        throw new Error('Function not implemented.');
      } } setIsAddingProduct={function (value: React.SetStateAction<boolean>): void {
        throw new Error('Function not implemented.');
      } }/>} />
    </Routes>
  );
  
  export default RoutesComponent;
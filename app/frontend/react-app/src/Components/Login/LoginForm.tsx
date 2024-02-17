import React, { useState, ChangeEvent, FormEvent } from 'react';
import axios from 'axios';

const LoginForm = ({ onLogin }: { onLogin: (user: { name: string; sub: string; email: string, role: string }) => void }) => {
  const [login, setLogin] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState('');

  const handleLoginChange = (event: ChangeEvent<HTMLInputElement>) => {
    setLogin(event.target.value);
  };

  const handlePasswordChange = (event: ChangeEvent<HTMLInputElement>) => {
    setPassword(event.target.value);
  };

  const handleSubmit = async (event: FormEvent<HTMLFormElement>) => {
    event.preventDefault();
  
    try {
      const response = await axios.post('http://localhost:5000/login', JSON.stringify({
        userLogin: login,
        userPassword: password,
      }), {
        headers: {
          'Content-Type': 'application/json'
        }
      });
  
      if (response.status === 200) {
        localStorage.setItem('accessToken', response.data.accessToken);
        localStorage.setItem('role', response.data.role);
        onLogin({ name: response.data.userName, sub: response.data.userId, email: response.data.email, role: response.data.role }); 

        // Получаем токен доступа и роль из localStorage и записываем их в консоль
        const accessToken = localStorage.getItem('accessToken');
        const role = localStorage.getItem('role');
        console.log(accessToken, role);
      } else {
        setError('Неверный логин или пароль');
      }
    } catch (error) {
      setError('Произошла ошибка при входе в систему');
    }
  };

  return (
    <form onSubmit={handleSubmit}>
      <label>
        Логин:
        <input type="text" value={login} onChange={handleLoginChange} />
      </label>
      <label>
        Пароль:
        <input type="password" value={password} onChange={handlePasswordChange} />
      </label>
      {error && <p>{error}</p>}
      <button type="submit">Войти</button>
    </form>
  );
};

export default LoginForm;
import React from 'react';
import WeatherTable from '../../WeatherForecast';
import Catalog from '../Catalog/Catalog';

const Home = ({ user, onLogout }: { user: { name: string; sub: string; email: string }, onLogout: () => void }) => {
  return (
    <div>
      <h1>Привет, {user.name}!</h1>
      <h2>Ваш ID: {user.sub}</h2>
      <h2>Ваш Email: {user.email}</h2>
      <button onClick={onLogout}>Выйти</button>
      <WeatherTable></WeatherTable>
      <Catalog></Catalog>
    </div>
  );
};

export default Home;
import React, { useCallback, useEffect, useState } from 'react';
import axios from 'axios';
import { useAuth } from 'oidc-react';

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

function WeatherTable() {
  const [data, setData] = useState<WeatherForecast[]>([]);
  const auth = useAuth();

  const fetchData = useCallback(async () => {
    const user = auth?.userData;
    if (user) {
      const accessToken = user.access_token; 
      const result = await axios.get('http://localhost:5000/weather', {
        headers: { Authorization: `Bearer ${accessToken}` },
      });
      setData(result.data);
    }
  }, [auth]);

  useEffect(() => {
    fetchData();
  }, [fetchData]);

  return (
    <div>
      <button onClick={fetchData}>Обновить данные о погоде</button>
      <table>
        <thead>
          <tr>
            <th>Дата</th>
            <th>Температура (C)</th>
            <th>Температура (F)</th>
            <th>Сводка</th>
          </tr>
        </thead>
        <tbody>
          {data.map((item, index) => (
            <tr key={index}>
              <td>{item.date}</td>
              <td>{item.temperatureC}</td>
              <td>{item.temperatureF}</td>
              <td>{item.summary}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default WeatherTable;
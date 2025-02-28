import React from "react";
import { Routes, Route } from "react-router-dom";
import "./App.css";
import DataProvider from "./store/DataProvider";
import Clients from "./pages/Client";
import 'bootstrap/dist/css/bootstrap.min.css';

export default function App() {
  return (
    <div className="App">
      <DataProvider>
        <Routes>
          <Route path="/" element={<Clients />} />
          <Route path="/Clients" element={<Clients />} />
        </Routes>
      </DataProvider>
    </div>
  );
}

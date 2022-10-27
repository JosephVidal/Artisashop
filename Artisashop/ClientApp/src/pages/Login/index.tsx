import React from "react";
import { Wrapper } from "./styles";

const Login = () => (
  <Wrapper>
    <div className="register-card">
      <h1>Artisashop</h1>
      <h2>Connexion</h2>
      <form action="submit">
        <input className="credentials" type="email" placeholder="Email"/>
        <input className="credentials" type="password" placeholder="Mot de passe"/>
        <button type="submit" id="register-button" className="red-button">Se connecter</button>
      </form>
      <p>Pas encore inscrit? <a href="/register">Rejoignez-nous</a> !</p>
    </div>
  </Wrapper>
);

export default Login;

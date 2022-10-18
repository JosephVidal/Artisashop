import React from "react";
import { Wrapper } from "./styles";

const Register = () => (
  <Wrapper>
    <div className="register-card">
      <h1>Artisashop</h1>
      <h2>Créer un compte <span id="account-type">client</span></h2>
      <form action="submit">
        <div id="register-name">
          <input type="text" placeholder="Prénom"/>
          <input type="text" placeholder="Nom"/>
        </div>
        <input className="credentials" type="text" placeholder="Email"/>
        <input className="credentials" type="text" placeholder="Mot de passe"/>
        <input className="credentials" type="text" placeholder="Confirmer mot de passe"/>
        <button type="submit" id="register-button" className="red-button">Créer un compte</button>
      </form>
      <p>Déjà inscrit? <a href="/login">Connectez-vous</a> !</p>
    </div>
  </Wrapper>
)

export default Register;

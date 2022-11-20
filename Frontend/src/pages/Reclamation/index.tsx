import React from "react";
import { Wrapper } from "./styles";

const ReclamationView = () => (
  <Wrapper>
    <div className="reclamation-card">
      <h1>Artisashop</h1>
      <h2>Réclamation</h2>
      <form action="submit">
        <input type="text" placeholder="Nom du produit" />
        <input className="text-longer" type="text" placeholder="Cause de la réclamation" />
        <input id="image-file" type="file" name="Image" />
        <button type="submit" id="contact-button" className="red-button">Terminé</button>
      </form>
    </div>
  </Wrapper>
);

export default ReclamationView;

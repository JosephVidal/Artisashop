import React from "react";
import { Container } from "./styles";

const NewsletterPage = () => (
  <Container>
    <h1 className="text">Bienvenue chez Artisashop</h1>
    <p className="text"><strong>Trouvez votre bonheur, vendez vos créations dans un espace unique et dédié à l art, où excellence rime avec savoir faire et élégance. Nos artisans sont impatients de vous présenter leurs ouvrages réalisés avec passion et expertise.</strong></p>
    <hr className="spacing" />
    <section className="text">
      <h1 className="text">Merci Joseph, votre commande a bien été enregistrée !</h1>
      <p><strong>Pour suivre votre commande, rendez-vous sur notre site artisashop.eu dans la rubrique Commandes.</strong></p>
      <button type="submit" className="red-button">Accéder</button>
    </section>
  </Container>
);

export default NewsletterPage;

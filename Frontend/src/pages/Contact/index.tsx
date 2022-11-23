import React from "react";
import { Contact } from "api/models/Contact";
import useFormattedDocumentTitle from "hooks/useFormattedDocumentTitle";
import { Wrapper } from "./styles";

const ContactView = () => {
  useFormattedDocumentTitle("Nous contacter");

  const contact: Contact =
  {
    subject: "",
    email: "",
    content: "",
    receiver: ""
  }

  return (
    <Wrapper>
      <div className="contact-card">
        <h1>Artisashop</h1>
        <h2>Contactez nous</h2>
        <form action="submit">
          <input className="credentials" type="email" placeholder="Email" />
          <input type="text" placeholder="Service" />
          <input type="text" placeholder="Sujet" />
          <input className="text-longer" type="text" placeholder="Message" />
          <button type="submit" id="contact-button" className="red-button">Envoyer</button>
        </form>
        <p>Ou envoyer un mail à artisashop@gmail.com</p>
      </div>
    </Wrapper>
  );
}

export default ContactView;

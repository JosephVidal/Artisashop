import { atom, useAtom } from "jotai";
import React from "react";
import { Link } from "react-router-dom";

import { contactListAtom } from "./+layout";

export const lastConversationAtom = atom<number | null>(null);

const DefaultChatPage = () => {
  const [contactList] = useAtom(contactListAtom);

  return (
    <div className="align-middle text-center my-auto py-12 text-xl">
      {contactList && (
        <p className="align-middle text-center text-xl">
          <b>Continuez où vous vous êtes arrêté !</b>
          <br />
          Sélectionnez une conversation dans le panneau à gauche afin de
          tchatter un peu 😁
        </p>
      )}
      Vous êtes à la recherche d&apos;artisans ?
      <br />
      <Link to="/search" className="text-black">
        Explorez les artisans
      </Link>
    </div>
  );
};

export default DefaultChatPage;

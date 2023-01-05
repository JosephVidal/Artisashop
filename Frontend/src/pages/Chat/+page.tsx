import { atom, useAtom } from "jotai";
import React from "react";
import { Link } from "react-router-dom";
import { ProductApi } from "api";
import useApi from "hooks/useApi";

import { contactListAtom } from "./+layout";

export const lastConversationAtom = atom<number | null>(null);

const EmptyChatPage = () => {
  const [contactList] = useAtom(contactListAtom);

  const productApi = useApi(ProductApi);

  const handleFire = async () => {
    const response = await productApi.apiProductCreatePost({
      description: "test",
      name: "test",
      price: 1,
      quantity: 1,
      images: [],
      styles: ["Scandinave"],
    });
    console.log(response);
  }

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

      <button type="button" onClick={handleFire}>Fire</button>
    </div>
  );
};

export default EmptyChatPage;

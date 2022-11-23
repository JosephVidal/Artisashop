import React from "react";

import { CreateProduct } from "api/models/CreateProduct";
import useFormattedDocumentTitle from "hooks/useFormattedDocumentTitle";
import { Wrapper } from "./styles";

const UpdateProductView = () => {
  useFormattedDocumentTitle("Panier");

  const product: CreateProduct =
  {
    name: "Product 1",
    description: "Description 1",
    price: 100,
    quantity: 2,
    images: ["default.png"],
    styles: ["moderne"]
  }

  return (
    <Wrapper>
      <div className="update-product-card">
        <h1>Artisashop</h1>
        <h2>Mettre à jour un produit</h2>
        <form action="submit">
          <input type="text" placeholder="Nom" />
          <div id="create-info">
            <input type="number" placeholder="Prix" />
            <input type="number" placeholder="Quantité" />
          </div>
          <input className="text-longer" type="text" placeholder="Description" />
          <input id="image-file" type="file" name="Image" />
          <input type="text" placeholder="Styles" />
          <button type="submit" id="contact-button" className="red-button">Terminé</button>
        </form>
      </div>
    </Wrapper>
  );
}

export default UpdateProductView;

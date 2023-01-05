import React from 'react';
import { ProductApi } from "api";
import { Field, Form, Formik } from "formik";
import useApi from "hooks/useApi";
import { useNavigate } from "react-router";
import useFormattedDocumentTitle from "hooks/useFormattedDocumentTitle";
import { Wrapper } from "./styles";

const CreateProductView = () => {
  useFormattedDocumentTitle("Créer un produit");
  const navigate = useNavigate()
  const productApi = useApi(ProductApi);

  return (
    <Wrapper>
      <div className="create-product-card">
        <h1>Artisashop</h1>
        <h2>Créer un produit</h2>
        <Formik
          initialValues={{
            name: '',
            price: 0,
            quantity: 0,
            description: '',
            images: [],
            styles: '',
          }}

          onSubmit={async values => {
            console.log(values.name)
            console.log(values.price)
            console.log(values.quantity)
            console.log(values.description)
            console.log(values.images)
            console.log(values.styles)
            await productApi.apiProductCreatePost({
              createProduct: {
                name: values.name,
                price: values.price,
                quantity: values.quantity,
                description: values.description,
                images: values.images,
                styles: values.styles.split(',').map(s => s.trim()),
              },
            })
              .then(res => {
                console.log(res);
                navigate("/dashboard");
              })
          }}
        >
          {({ isSubmitting, setFieldValue }) => (
            <Form>
              <Field id="name" name="name" type="text" placeholder="Nom" />
              <div id="create-info">
                <label htmlFor="price">Prix</label>
                <label htmlFor="quantity">Quantité</label>
              </div>
              <div id="create-info">
                <Field id="price" name="price" type="number" placeholder="Prix" />
                <Field id="quantity" name="quantity" type="number" placeholder="Quantité" />
              </div>
              <Field as="textarea" id="description" name="description" className="message" rows={5} cols={33} placeholder="Description" />
              <input id="fileinput" type="file" onChange={(event) => {
                setFieldValue("images", event.target.files);
              }}
              />
              <Field id="styles" name="styles" type="text" placeholder="Styles" />
              <button type="submit" id="contact-button" className="red-button" disabled={isSubmitting}>Terminé</button>
            </Form>
          )}
        </Formik>
      </div>
    </Wrapper>
  );
}

export default CreateProductView;

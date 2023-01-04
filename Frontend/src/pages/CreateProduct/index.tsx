import React, { useEffect } from 'react';
import { Field, Form, Formik } from "formik";
import useApi from "hooks/useApi";
import useAsync from "hooks/useAsync";
import { ProductApi } from "api";
import useFormattedDocumentTitle from "hooks/useFormattedDocumentTitle";
import { Wrapper } from "./styles";

const CreateProductView = () => {
  useFormattedDocumentTitle("Créer un produit");
  const ProducttApi = useApi(ProductApi)

  const { value, status, error, execute } = useAsync(() => ProducttApi.apiProductCreatePost({
    name: '',
    price: 0,
    quantity: 0,
    description: '',
    images: [],
    styles: [],
  }), false);

  useEffect(() => { if (!null) { execute(); } }, []);

  return (
    <Wrapper>
      <div className="create-product-card">
        <h1>Artisashop</h1>
        <h2>Créer un produit</h2>
        <Formik
          initialValues={{
            name: '',
            price: '',
            quantity: '',
            description: '',
            images: '',
            styles: '',
          }}

          onSubmit={async values => { }}

          validate={values => { }}
        >
          {({ isSubmitting }) => (
            <Form>
              <Field id="nom" name="nom" type="text" placeholder="Nom" />
              <div id="create-info">
                <Field id="price" name="price" type="number" placeholder="Prix" />
                <Field id="quantity" name="quantity" type="number" placeholder="Quantité" />
              </div>
              <Field as="textarea" id="description" name="description" className="message" rows={5} cols={33} placeholder="Description" />
              <Field id="image-file" type="file" name="Image" />
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

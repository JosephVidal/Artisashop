import React, { useEffect } from "react";
import useFormattedDocumentTitle from "hooks/useFormattedDocumentTitle";
import { Field, Form, Formik } from "formik";
import useApi from "hooks/useApi";
import useAsync from "hooks/useAsync";
import { CreateProduct, ProductApi } from "api";
import { Wrapper } from "./styles";

const UpdateProductView = () => {
  useFormattedDocumentTitle("Panier");
  const ProducttApi = useApi(ProductApi);

  const initialValues: CreateProduct = {
    name: '',
    price: 0,
    quantity: 0,
    description: '',
    images: [],
    styles: [],
  };

  return (
    <Wrapper>
      <div className="update-product-card">
        <h1>Artisashop</h1>
        <h2>Mettre à jour un produit</h2>
        <Formik
          enableReinitialize
          initialValues={initialValues}
          onSubmit={async values => { 
            await ProducttApi.updateProduct({ productId: , createProduct: values })
          }}

          validate={values => { }}
        >
          {({ isSubmitting }) => (
            <Form>
              <Field type="text" placeholder="Nom" />
              <div id="create-info">
                <Field type="number" placeholder="Prix" />
                <Field type="number" placeholder="Quantité" />
              </div>
              <Field as="textarea" className="message" rows={5} cols={33} placeholder="Description" />
              <Field id="image-file" type="file" name="Image" />
              <Field type="text" placeholder="Styles" />
              <button type="submit" id="contact-button" className="red-button" disabled={isSubmitting}>Terminé</button>
            </Form>
          )}
        </Formik>
      </div>
    </Wrapper>
  );
}

export default UpdateProductView;

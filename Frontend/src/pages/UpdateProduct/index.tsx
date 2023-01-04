import React, {useEffect, useMemo} from "react";
import useFormattedDocumentTitle from "hooks/useFormattedDocumentTitle";
import { Field, Form, Formik } from "formik";
import useApi from "hooks/useApi";
import useAsync from "hooks/useAsync";
import {Account, Product, ProductApi} from "api";
import {useSearchParams} from "react-router-dom";
import { Wrapper } from "./styles";

const UpdateProductView = () => {
  useFormattedDocumentTitle("Panier");
<<<<<<< HEAD
  const productApi = useApi(ProductApi);
  const [searchParams] = useSearchParams();
  const product: Product | null = useMemo(() => {
    const param = searchParams.get("product");
    if (param !== null)
      return JSON.parse(param) as Product
    return null;
  }, [searchParams]);
=======
  const ProducttApi = useApi(ProductApi)

  const { value : update, status, error, execute } = useAsync(() => ProducttApi.apiProductCreatePost({
    name: '',
    price: 0,
    quantity: 0,
    description: '',
    images: [],
    styles: [],
  }), false);

  useEffect(() => { execute() }, []);
>>>>>>> origin/dev

  return (
    <Wrapper>
      <div className="update-product-card">
        <h1>Artisashop</h1>
        <h2>Mettre à jour un produit</h2>
        <Formik
          enableReinitialize
          initialValues={{
            name: product?.name ?? '',
            price: product?.price ?? '',
            quantity: product?.quantity ?? '',
            description: product?.description ?? '',
            images: product?.productImages ?? '',
            styles: product?.productImages ?? '',
          }}

          onSubmit={async values => { }}

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

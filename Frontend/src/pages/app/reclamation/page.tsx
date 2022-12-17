import React, { useEffect } from "react";
import useFormattedDocumentTitle from "hooks/useFormattedDocumentTitle";
import { Field, Form, Formik } from "formik";
import useApi from "hooks/useApi";
import useAsync from "hooks/useAsync";
import { ComplaintApi } from "api";
import { Wrapper } from "./styles";

const ReclamationView = () => {
  const ComplainttApi = useApi(ComplaintApi)
  useFormattedDocumentTitle("Réclamation");

  const { value, status, error, execute } = useAsync(() => ComplainttApi.apiComplaintPost({}), false);

  useEffect(() => { if (!null) { execute(); } }, []);

  return (
    <Wrapper>
      <div className="reclamation-card">
        <h1>Artisashop</h1>
        <h2>Réclamation</h2>
        <Formik
          initialValues={{
            email: '',
            subject: '',
            content: '',
            receiver: '',
          }}

          onSubmit={async values => { }}

          validate={values => { }}
        >
          {({ isSubmitting }) => (
            <Form>
          <Field id="name" name="name" type="text" placeholder="Nom du produit" />
          <Field as="textarea" id="description" name="description" className="message" rows={5} cols={33} placeholder="Cause de la réclamation" />
              <button type="submit" id="contact-button" className="red-button" disabled={isSubmitting}>Terminé</button>
        </Form>
          )}
      </Formik>
      </div>
    </Wrapper>
  );
}

export default ReclamationView;

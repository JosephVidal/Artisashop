import React, { useEffect } from "react";
import { Field, Form, Formik } from "formik";
import useApi from "hooks/useApi";
import useAsync from "hooks/useAsync";
import { ContactApi } from "api";
import useFormattedDocumentTitle from "hooks/useFormattedDocumentTitle";
import { Wrapper } from "./styles";

const ContactView = () => {
  useFormattedDocumentTitle("Nous contacter");
  const ContacttApi = useApi(ContactApi)

  const { value, status, error, execute } = useAsync(() => ContacttApi.apiContactPost({}), false);

  useEffect(() => { if (!null) { execute(); } }, []);

  return (
    <Wrapper>
      <div className="contact-card">
        <h1>Artisashop</h1>
        <h2>Contactez nous</h2>
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
              <Field className="credentials" id="email" name="email" placeholder="Email" />
              <Field as="select" className="services" id="service-select" name="service" >
                <option value="client">Client</option>
                <option value="sales">Sales</option>
              </Field>
              <Field id="sujet" name="sujet" placeholder="Sujet" />
              <Field as="textarea" id="message" name="message" className="message" rows={5} cols={33} placeholder="Message" />
              <button id="contact-button" name="contact-button" type="submit" className="red-button" disabled={isSubmitting}>Envoyer</button>
            </Form>
          )}
        </Formik>
        <p>Ou envoyer un mail à artisashop@gmail.com</p>
      </div>
    </Wrapper>
  );
}

export default ContactView;

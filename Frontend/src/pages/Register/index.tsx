import React from "react";
import { useNavigate } from "react-router";
import { Formik, Field, Form } from "formik";
import { Link } from "react-router-dom";

import useFormattedDocumentTitle from "hooks/useFormattedDocumentTitle";
import useAuth from "states/auth";
import { Wrapper } from "./styles";

const Register = () => {
  const auth = useAuth()
  const navigate = useNavigate()

  useFormattedDocumentTitle("S'enregister");


  return (
    <Wrapper>
      <div className="register-card">
        <h1>Artisashop</h1>
        <h2>Créer un compte</h2>
        <Formik
          initialValues={{
            firstname: '',
            lastname: '',
            email: '',
            password: '',
            passwordConfirm: '',
            role: "USER",
          }}

          onSubmit={async values => {
            await auth?.signup(values)
              .then(res => res.user && navigate("/"))
          }}

          validate={values => {
            const errors: { [key: string]: string } = {};
            if (values.password !== values.passwordConfirm) {
              errors.password = "*Les mots de passe ne sont pas identiques";
            }
            return errors;
          }}
        >
          {({ isSubmitting }) => (
            <Form>
              <div id="register-name">
                <Field type="text" name="firstname" placeholder="Prénom" />
                <Field type="text" name="lastname" placeholder="Nom" />
              </div>
              <Field className="credentials" name="email" type="email" placeholder="Email" />
              <Field className="credentials" name="password" type="password" placeholder="Mot de passe" />
              <Field className="credentials" name="passwordConfirm" type="password" placeholder="Confirmer mot de passe" />
              <button type="submit" id="register-button" className="red-button" disabled={isSubmitting}>
                Créer un compte
              </button>
            </Form>
          )}
        </Formik>
        <p>Déjà inscrit? <Link to="/app/login">Connectez-vous</Link> !</p>
      </div>
    </Wrapper>
  );
}

export default Register;

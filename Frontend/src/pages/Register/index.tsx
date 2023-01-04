import React from "react";
import { useNavigate } from "react-router";
import { Formik, FormikErrors, Field, Form, ErrorMessage } from "formik";
import { Link } from "react-router-dom";

import useFormattedDocumentTitle from "hooks/useFormattedDocumentTitle";
import useAuth from "states/auth";
import { Wrapper } from "./styles";

interface FormValues {
  firstname: string;
  lastname: string;
  email: string;
  password: string;
  passwordConfirm: string;
  role: string;
}

function validate(values: FormValues): FormikErrors<FormValues> {
  const errors = {} as FormValues;

  if (!values.email)
    errors.email = 'Email requis';
  else if (!/^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}$/i.test(values.email))
    errors.email = 'Email invalide';
  if (!values.password)
    errors.password = 'Mot de passe requis';
  else if (!/^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$/i.test(values.password))
    errors.password = 'Le mot de passe doit contenir au moins une majuscule, un chiffre, un caractère spécial, et doit faire 8 caractères minimum';
  if (!values.firstname || !values.lastname)
    errors.firstname = 'Nom et prénom requis';
  if (values.password !== values.passwordConfirm)
    errors.passwordConfirm = 'Le mot de passe et la confirmation doivent être identiques';
  return errors;
}

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

          validate={validate}
          onSubmit={async values => {
            await auth?.signup(values)
              .then(res => res.user && navigate("/"))
          }}
        >
          {({ isSubmitting }) => (
            <Form>
              <div id="register-name">
                <Field type="text" name="firstname" placeholder="Prénom" />
                <Field type="text" name="lastname" placeholder="Nom" />
              </div>
              <ErrorMessage name="firstname" component="div" />
              <Field className="credentials" name="email" type="email" placeholder="Email" />
              <ErrorMessage name="email" component="div" />
              <Field className="credentials" name="password" type="password" placeholder="Mot de passe" />
              <ErrorMessage name="password" component="div" />
              <Field className="credentials" name="passwordConfirm" type="password" placeholder="Confirmer mot de passe" />
              <ErrorMessage name="passwordConfirm" component="div" />
              <button type="submit" id="register-button" className="red-button" disabled={isSubmitting}>
                Créer un compte
              </button>
            </Form>
          )}
        </Formik>
        <p>Déjà inscrit? <Link to="/login">Connectez-vous</Link> !</p>
      </div>
    </Wrapper>
  );
}

export default Register;

import React from "react";
import { Field, Form, Formik, FormikErrors, ErrorMessage } from "formik";
import { useNavigate } from "react-router";
import { Link } from "react-router-dom";
import useFormattedDocumentTitle from "hooks/useFormattedDocumentTitle";
import useAuth from "../../states/auth";
import { Wrapper } from "./styles";

interface FormValues {
  email: string;
  password: string;
}

function validate(values: FormValues): FormikErrors<FormValues> {
  const errors = {} as FormValues;
  if (!values.email)
    errors.email = 'Email is required';
  else if (!/^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}$/i.test(values.email))
    errors.email = 'Invalid email address';
  if (!values.password)
    errors.password = 'Password is required';
  return errors;
}

const Login = () => {
  const auth = useAuth()
  const navigate = useNavigate()
  useFormattedDocumentTitle("Se connecter");

  return (
    <Wrapper>
      <div className="register-card">
        <h1>Artisashop</h1>
        <h2>Connexion</h2>
        <Formik
          initialValues={{
            email: "",
            password: "",
          }}
          validate={validate}
          onSubmit={async (values, { setErrors }) => {
            await auth?.signin(values.email, values.password)
              .then(res => res.user && navigate("/"))
              .catch(() => setErrors({ password: "Email ou mot de passe invalide" }))
          }}
        >
          {({ isSubmitting }) => (
            <Form>
              <Field className="credentials" name="email" type="email" placeholder="Email" />
              <ErrorMessage name="email" component="div" />
              <Field className="credentials" name="password" type="password" placeholder="Mot de passe" />
              <ErrorMessage name="password" component="p" />
              <button type="submit" id="register-button" className="red-button" disabled={isSubmitting}>
                Se connecter
              </button>
            </Form>
          )}
        </Formik>
        <p>Pas encore inscrit? <Link to="/app/register">Rejoignez-nous</Link> !</p>
      </div>
    </Wrapper>
  );
};

export default Login;

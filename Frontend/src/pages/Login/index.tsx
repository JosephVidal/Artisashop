import React from "react";
import { Field, Form, Formik } from "formik";
import { useNavigate } from "react-router";
import { Link } from "react-router-dom";
import useFormattedDocumentTitle from "hooks/useFormattedDocumentTitle";
import useAuth from "../../states/auth";
import { Wrapper } from "./styles";

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
          onSubmit={async values => {
            await auth?.signin(values.email, values.password)
              .then(res => res.user && navigate("/"))
          }}
        >
          {({ isSubmitting }) => (
            <Form>
              <Field className="credentials" name="email" type="email" placeholder="Email" />
              <Field className="credentials" name="password" type="password" placeholder="Mot de passe" />
              <button type="submit" id="register-button" className="red-button" disabled={isSubmitting}>
                Se connecter
              </button>
            </Form>
          )}
        </Formik>
        <p>Pas encore inscrit? <Link to="/register">Rejoignez-nous</Link> !</p>
      </div>
    </Wrapper>
  );
};

export default Login;

import React from "react";
import { Field, Form, Formik } from "formik";
import { useNavigate } from "react-router";
import { Link } from "react-router-dom";
import { useAuth } from "../../hooks/useAuth";
import { Wrapper } from "./styles";
import GoogleLogin from "../../components/GoogleLogin";

const Login = () => {
  const auth = useAuth()
  const navigate = useNavigate()

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
          onSubmit={values => {
            auth?.signin(values.email, values.password)
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
        <div>
          <GoogleLogin />  
        </div>
        <p>Pas encore inscrit? <Link to="/register">Rejoignez-nous</Link> !</p>
      </div>
    </Wrapper>
  );
};

export default Login;

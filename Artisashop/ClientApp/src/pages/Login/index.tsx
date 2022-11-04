import React from "react";
import {useFormik} from "formik";
import {useNavigate} from "react-router";
import {Link} from "react-router-dom";
import {useAuth} from "../../hooks/useAuth";
import {Wrapper} from "./styles";

const Login = () => {
  const auth = useAuth()
  const navigate = useNavigate()
  const formik = useFormik({
    initialValues: {
      email: "",
      password: "",
    },
    onSubmit: (values => {
        auth?.signin(values.email, values.password)
          .then(res => res.user && navigate("/"))
      }
    )
  })

  return (
    <Wrapper>
      <div className="register-card">
        <h1>Artisashop</h1>
        <h2>Connexion</h2>
        <form onSubmit={formik.handleSubmit}>
          <input className="credentials"
                 name="email"
                 type="email"
                 placeholder="Email"
                 value={formik.values.email}
                 onChange={formik.handleChange}
          />
          <input className="credentials"
                 name="password"
                 type="password"
                 placeholder="Mot de passe"
                 value={formik.values.password}
                 onChange={formik.handleChange}
          />
          <button type="submit" id="register-button" className="red-button">Se connecter</button>
        </form>
        <p>Pas encore inscrit? <Link to="/register">Rejoignez-nous</Link> !</p>
      </div>
    </Wrapper>
  );
};

export default Login;

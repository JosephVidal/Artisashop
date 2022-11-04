import React from "react";
import {useNavigate} from "react-router";
import {useFormik} from "formik";
import {Link} from "react-router-dom";
import {Wrapper} from "./styles";
import {useAuth} from "../../hooks/useAuth";
import {UserType} from "../../api";

const Register = () => {
  const auth = useAuth()
  const navigate = useNavigate()
  const formik = useFormik({
    initialValues: {
      firstname: '',
      lastname: '',
      email: '',
      password: '',
      passwordConfirm: '',
      role: UserType.NUMBER_0,
    },
    validate: (values => {
      let error = {};

      if (values.password !== values.passwordConfirm) {
        error = "*Les mots de passe ne sont pas identiques";
      }

      return error;
    }),
    onSubmit: (values => {
        auth?.signup(values)
          .then(res => res.user && navigate("/"))
      }
    )
  })

  return (
    <Wrapper>
      <div className="register-card">
        <h1>Artisashop</h1>
        <h2>Créer un compte <span id="account-type">client</span></h2>
        <form onSubmit={formik.handleSubmit}>
          <div id="register-name">
            <input type="text"
                   name="firstname"
                   placeholder="Prénom"
                   value={formik.values.firstname}
                   onChange={formik.handleChange}
            />
            <input type="text"
                   name="lastname"
                   placeholder="Nom"
                   value={formik.values.lastname}
                   onChange={formik.handleChange}
            />
          </div>
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
          <input className="credentials" 
                 name="passwordConfirm" 
                 type="password" 
                 placeholder="Confirmer mot de passe"
                 value={formik.values.passwordConfirm}
                 onChange={formik.handleChange}
          />
          <button type="submit" id="register-button" className="red-button">Créer un compte</button>
        </form>
        <p>Déjà inscrit? <Link to="/login">Connectez-vous</Link> !</p>
      </div>
    </Wrapper>
  );
}

export default Register;

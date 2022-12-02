import React, { useEffect } from "react";
import { useAtom } from "jotai";
import { Field, Form, Formik } from "formik";

import { AccountApi } from "api";
import useApi from "hooks/useApi";
import useAsync from "hooks/useAsync";
import userAtom from "states/atoms/user";
import useAuth from "states/auth";
import useFormattedDocumentTitle from "hooks/useFormattedDocumentTitle";
import { Wrapper } from './styles';

const ProfilePage = () => {
  useFormattedDocumentTitle("Votre Profil");

  const accounApi = useApi(AccountApi)
  const [user] = useAtom(userAtom)
  const auth = useAuth()

  const { value: profile, status, error, execute } = useAsync(() => accounApi.getAccountFromId({ id: user?.id ?? '' }), false);
  // Executes only if user is defined
  useEffect(() => { if (user?.id) { execute(); } }, [user])

  return (
    <Wrapper>
      <div className="profile-card">
        <h1>Bonjour, {profile?.account?.firstname} {profile?.account?.lastname}</h1>

        <section>
          <h2>Vos informations</h2>
          <Formik
            enableReinitialize
            initialValues={{
              email: profile?.account?.email ?? '',
              firstname: profile?.account?.firstname ?? '',
              lastname: profile?.account?.lastname ?? '',
              password: '',
              passwordConfirmation: '',
            }}

            onSubmit={async values => {
              accounApi.updateCurrentAccount({
                updateAccount:
                {
                  email: values.email,
                  firstname: values.firstname,
                  lastname: values.lastname,
                  // phoneNumber: "",
                  // job: "",
                }
              });
            }}

            validate={values => { }}
          >
            {({ isSubmitting }) => (
              <Form>
                <div style={{ display: "flex", flexDirection: "row", width: "100%", justifyContent: "space-between" }}>
                  <div style={{ display: "flex", flexDirection: "column" }}>
                    <label htmlFor="firstname">Prénom</label>
                    <Field className="credentials" name="firstname" type="text" placeholder="Prénom" />
                  </div>
                  <div style={{ display: "flex", flexDirection: "column" }}>
                    <label htmlFor="lastname">Nom</label>
                    <Field className="credentials" name="lastname" type="text" placeholder="Nom" />
                  </div>
                </div>
                <label htmlFor="email">Email</label>
                <Field className="credentials" name="email" type="email" placeholder="Email" />
                <button
                  type="submit"
                  className="red-button"
                  style={{ marginTop: "15px" }}
                  disabled={isSubmitting}
                >
                  Mettre à jour
                </button>
              </Form>
            )}
          </Formik>
        </section>

        <hr className="spacing" />

        <section>
          <h2>Connexions tierces</h2>

          <div>
            <h3>Google</h3>
          </div>

          <div>
            <h3>FranceConnect</h3>
            <p>Vous êtes connecté avec FranceConnect</p>
            <a href="https://franceconnect.gouv.fr/">En savoir plus sur FranceConnect</a>
          </div>
        </section>

        <section>
          <h3>Se déconnecter</h3>
          <button type="button" className="red-button" onClick={() => auth.signout()}>Se déconnecter</button>
        </section>
      </div>
    </Wrapper >
  );
};

export default ProfilePage;

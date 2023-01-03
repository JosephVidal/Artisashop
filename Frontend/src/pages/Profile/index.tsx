import React, {useEffect, useState} from "react";
import { useAtom } from "jotai";
import { Field, Form, Formik } from "formik";

import { AccountApi } from "api";
import useApi from "hooks/useApi";
import useAsync from "hooks/useAsync";
import userAtom from "states/atoms/user";
import useAuth from "states/auth";
import useFormattedDocumentTitle from "hooks/useFormattedDocumentTitle";
import {FlexRow, Wrapper } from './styles';

const ProfilePage = () => {
  useFormattedDocumentTitle("Votre Profil");

  const accounApi = useApi(AccountApi)
  const [user] = useAtom(userAtom)
  const auth = useAuth()

  const { value: profile, status, error, execute } = useAsync(() => accounApi.apiAccountIdGet({ id: user?.id ?? '' }), false);
  // Executes only if user is defined
  useEffect(() => { if (user?.id) { execute(); } }, [user])

  const [seller, setSeller] = useState(profile && profile?.roles?.includes("SELLER"));

  useEffect(() => setSeller(profile && profile?.roles?.includes("SELLER")), [profile])

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

            onSubmit={async values => { }}

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
                <button type="submit" className="red-button" style={{ marginTop: "15px" }} disabled={isSubmitting}>Mettre à jour</button>
              </Form>
            )}
          </Formik>
        </section>

        <hr className="spacing" />

        <section>
          <h2>Connexions tierces</h2>
          {["Facebook", "Google", "FranceConnect"].map((value) => (

            <div key={value} style={{ display: "flex", flexDirection: "row", justifyContent: "space-between", marginTop: '5px' }}>
              <h3>{value}</h3>
              <button type="button" className="red-button">Ajouter</button>
            </div>
          ))}
        </section>

        <section>
          <FlexRow>
            {profile && !seller &&
              <button type="button" className="red-button" onClick={() => accounApi.apiAccountIdRoleRolePostRaw({
                id: profile.account!.id!,
                role: "SELLER",
                isDeleted: false
              }).then((result) => {
                console.log(result)
                if (result.raw.status === 200) {
                  console.log(result.raw.status)
                  setSeller(true);
                }
              })}>Je suis un artisan</button>
            }
            <button type="button" className="red-button" onClick={() => auth.signout()}>Se déconnecter</button>
          </FlexRow>
        </section>
      </div>
    </Wrapper>
  );
};

export default ProfilePage;

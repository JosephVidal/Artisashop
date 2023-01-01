import styled from "styled-components";

export const Wrapper = styled.div`
    .profile-card {
        width: 40em;
        border-radius: var(--elem-radius);
        background-color: var(--artshp-dark-blue);
        padding: 40px;
        margin: 1em auto;
        color: var(--artshp-white);

        h1 {
          font-family: Helvetica;
        text-align: center;
        }

        h2 {
            font-family: Helvetica;
            font-weight: lighter;
        }

        form {
            display: flex;
            flex-direction: column;
        }

        input {margin: 10px 0}

        .spacing {
          margin: 30px 0;
        }
    }
`;

export const FlexRow = styled.div`
  margin-top: 20px;
  display: flex;
  flex-direction: row;
  justify-content: space-between;
`;

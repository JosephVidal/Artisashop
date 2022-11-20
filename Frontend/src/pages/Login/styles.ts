import styled from "styled-components";

export const Wrapper = styled.div`
    .register-card {
        display: flex;
        flex-direction: column;
        text-align: center;
        width: 40vw;
        border-radius: var(--elem-radius);
        background-color: var(--artshp-dark-blue);
        padding: 40px;
        margin: 10vh auto;
        color: var(--artshp-white);

        h1 {
            font-family: Artisashop;
            font-size: 6em;
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

        #register-name {
            display: flex;
            justify-content: space-between;
        }

        #register-button {
            margin-top: 40px;
            font-size: 1.3em;
        }
    }
`;
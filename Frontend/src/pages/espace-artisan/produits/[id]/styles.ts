import styled from "styled-components";

export const Wrapper = styled.div`
        .update-product-card {
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

        #contact-button {
            margin-top: 40px;
            font-size: 1.3em;
        }

        #create-info {
            display: flex;
            justify-content: space-between;
        }

        #image-file {
            background-color: transparent;
            margin-left: -5px;
        }

        .message {
            border-radius: var(--elem-radius);
            background-color: var(--bs-light);
            margin: 10px 0;
            padding-left: 7px;
            padding-top: 5px;
            font-size: 1.2em;
            color: black;
        }
}
`;

import styled from "styled-components";

export const Wrapper = styled.div`
       .contact-card {
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

        .text-longer {
            height: 30px;
        }
    }
        
    .md\: px-6 {
        padding-left: 3rem!important;
        padding-right: 3rem!important;
    }
         
    .py-5 {
        padding-top: 2rem!important;
        padding-bottom: 2rem!important;
    }

    .grid {
        display: flex;
        color: white;
        flex-wrap: wrap;
        margin-right: -0.5rem;
        margin-left: 21rem;
        margin-top: -0.5rem;
    }

    .col-12 {
        padding: 10px;
    }
    
    .surface-card {
        background-color: black!important;
    }
     
    .p-3 {
        padding: 1rem!important;
    }

    .mb-3 {
        margin-bottom: 1rem!important;
    }

    .justify-content-between {
        justify-content: space-between!important;
    }

    .flex {
        display: flex!important;
    }

    * {
        box-sizing: border-box;
    }

    .font-medium {
        font-weight: 600!important;
    }

    .text-green-500 {
        color: green!important;
    }

    .text-500 {
        color: grey!important;
    }
    
    .shadow-2 {
        box-shadow: 0 4px 10px rgba(0, 0, 0, .03), 0 0 2px rgba(0, 0, 0, .06), 0 2px 6px rgba(0, 0, 0, .12)!important;
    }

    div {
        display: block;
    }
}
`;

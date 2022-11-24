import styled from "styled-components";

export const Wrapper = styled.div`
section {
    margin: 0;

    h2 {
        font-family: Helvetica;
        font-weight: lighter;
        font-size: 3em;
        margin: 0;
    }
}

.search-input {width: 20vw;}

#search-section {
    display: flex;
    align-items: center;
    justify-content: center;
    flex-direction: column;
    height: 80vh;
    background-image: url("/img/home background.jpg");
    background-size: cover;
    background-attachment: fixed;

    h1 {
        display: block;
        color: var(--artshp-white);
        font-family: Artisashop;
        font-size: 8em;
        margin: 0;
    }
}

.section-body {
    display: flex;
    flex-direction: row;
    flex-wrap: wrap;
    justify-content: space-around;
    margin-top: 80px;
}

#product-section, #craftsman-section {
    padding: 4%;
    padding-bottom: 40px;
}

#product-section {
    color: var(--artshp-white);
    background-color: var(--artshp-dark-blue);

    #product-text {
        font-size: 2em;
        font-weight: lighter;
        margin-top: 5%;
    }
}

#craftsman-section {
    color: var(--artshp-dark-blue);
    background-color: var(--artshp-white);
}

#register-section {
    display: flex;
    flex-direction: row;
    height: 80vh;
    align-items: center;

    p {margin-bottom: 60px}

    div {
        height: 100%;
        width: 50vw;
        text-align: center;
        font-size: 2.5em;
        padding: 50px;

        h2 {
            font-size: 2em;
            padding-bottom: 60px;
        }
    }
}

.md: px-6 {
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
        margin-top: -0.5rem;
    }

    .col-12 {
        padding: 10px;
    }

    .surface-card {
        background-color: var(--artshp-dark-blue);!important;
    }

    .p-3 {
        padding: 2rem!important;
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
        font-size: 2.2em;
        margin-bottom: 1rem!important;
    }

    .text-green-500 {
        color: green!important;
        font-size: 2.2em;
    }

    .text-500 {
        color: grey!important;
        font-size: 2.2em;
    }

    .shadow-2 {
        box-shadow: 0 4px 10px rgba(0, 0, 0, .03), 0 0 2px rgba(0, 0, 0, .06), 0 2px 6px rgba(0, 0, 0, .12)!important;
    }

    div {
        display: block;
    }

#register-dark {background-color: var(--artshp-dark-blue);}
#register-light {
    background-color: var(--artshp-white);
    color: var(--artshp-red);
}

#searchType, .wordCarousel {margin-left: 10px;}

.wordCarousel {
    color: var(--artshp-white);
    height: 100%;
}

.search-type-text {
    margin: auto 0;
}

.flip2 {
    animation: flip2 1s cubic-bezier(0.23, 1, 0.32, 1.2);
    margin-top: -53px;
}

.flip3 {
    animation: flip3 1s cubic-bezier(0.23, 1, 0.32, 1.2);
    margin-top: -5px;
}

@keyframes flip2 {
    0% {margin-top: -5px;}

    100% {margin-top: -53px;}
}

@keyframes flip3 {
    0% {margin-top: -53px;}

    100% {margin-top: -5px;}
}

@media (max-width: 1300px) {
    #register-section {
        div {font-size: 1.5em;}
    }
}

@media (max-width: 930px) {
    #register-section {
        div {font-size: 1em;}
    }
}
`;

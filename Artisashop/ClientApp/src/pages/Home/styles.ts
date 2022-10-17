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

.search-input {
    background-color: var(--bs-white);
    border: 0;
    border-radius: var(--elem-radius);
    padding: 3px;
    padding-left: 7px;
    margin-right: 10px;
    width: 20vw;
    font-size: 1.2em;

    ::placeholder {color: var(--artshp-dark-blue)}
    :focus {border: solid 1px var(--artshp-orange)}
}

.search-button {
    border: 0;
    color: var(--artshp-white);
    border-radius: var(--elem-radius);
    background-color: var(--artshp-blue);
    transition: 0.3s;

    &:hover {
        background-color: var(--bs-light);
        color: var(--bs-dark);
    }
}

#search-section {
    display: flex;
    align-items: center;
    justify-content: center;
    flex-direction: column;
    height: 80vh;
    background-image: url("../assets/31.jpeg");
    background-attachment: fixed;
    background-color: var(--artshp-orange);

    h1 {
        display: block;
        color: var(--artshp-white);
        font-family: Artisashop;
        font-size: 8em;
        margin: 0;
    }

    #search-block {display: inline;}
}

.section-body {
    display: flex;
    flex-direction: row;
    justify-content: space-around;
    margin-top: 80px;
}

.cta-home {
    border-radius: var(--elem-radius);
    background-color: var(--artshp-red);
    color: var(--artshp-white);
    text-decoration: none;
    font-weight: bolder;
    padding: 10px 40px;
    margin-top: 90px;
    transition: 0.3sec;
    font-size: 0.8em;

    :hover {background-color: var(--artshp-orange);}
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

    p {margin-bottom: 30%}

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

#register-light {
    background-color: var(--artshp-white);
    color: var(--artshp-red);
}

.wordCarousel {color: var(--artshp-white);}

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
`;
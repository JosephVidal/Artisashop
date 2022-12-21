import styled, { keyframes } from "styled-components";

const tiltShaking = keyframes`
    0% { transform: rotate(0deg); }
    25% { transform: rotate(2deg); }
    50% { transform: rotate(0eg); }
    75% { transform: rotate(-2deg); }
    100% { transform: rotate(0deg); }
`

export const Tag = styled.span`
    padding: 3px 10px;
    border-radius: var(--elem-radius);
    background-color: var(--artshp-brown);
    color: var(--artshp-white);

    :not(:first-of-type) {margin-left: 5px;}

    @media (max-width: 620px) {
        font-size: 0.5em;
    }
`;

export const Craftsman = styled.div`
    display: flex;
    flex-direction: row;
    text-align: left;
    font-size: 30px;
    font-weight: lighter;
    padding-bottom: 30px;

    img {
        width: 50px;
        height: 50px;
        /* object-fit: cover; */
        margin-right: 20px;
        object-fit: fill;
        border-radius: 100%;
        box-shadow: 0px 0px 30px #a0a0a0;
    }

    a:hover {color: var(--artshp-orange);}
    a {
        text-decoration: none;
        margin: auto 0;
    }

    @media (max-width: 1250px) {
        a {font-size: 0.6em}
    }
`;

export const Wrapper = styled.div`
    #product-page {
        display: flex;
        flex-direction: row;
        justify-content: space-between;
        padding: 15vh 10vw;
        color: var(--artshp-dark-blue);
    }

    #product-info {
        max-width: 30vw;
        height: 600px;
        width: auto;

        h1 {
            font-size: 45px;
            padding-bottom: 30px;
        }

        button {width: 100%;}

        a {color: var(--bs-dark);}

        #description {font-size: 20px;}

        #tags {padding-bottom: 40px;}

        #stock {color: var(--bs-red);}

        #price {font-size: 40px;}
    }

    .carrousel-img {
        width: 600px;
        height: 600px;
        object-fit: cover;
        border-radius: var(--elem-radius);
        transition: var(--artshp-trans);
    }

    .active {
        animation : ${tiltShaking} 0.2s linear;
        transition: var(--artshp-trans);
        background-color : rgb(2, 162, 23);
    }

    @media (max-width: 1250px) {
        #product-info {padding-left: 10px;}

        #price {
            margin: 0;
            font-size: 0.1em;
        }

        .carrousel-img {
            width: 300px;
            height: 300px;
        }

        h1 {font-size: 1.5em !important;}
    }
`;

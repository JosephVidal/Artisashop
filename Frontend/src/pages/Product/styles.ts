import styled from "styled-components";

export const Tag = styled.span`
    padding: 3px 10px;
    border-radius: var(--elem-radius);
    background-color: var(--bs-brown);
    color: var(--bs-light);
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

    a {
        text-decoration: none;
        margin: auto 0;
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
    }
`;
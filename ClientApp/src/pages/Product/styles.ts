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
    font-size: 30px;
    font-weight: lighter;
    padding-bottom: 30px;

    img {
        width: auto;
        height: auto;
    }

    a {
        text-decoration: none;
        margin: auto;
    }
`;

export const Wrapper = styled.div`
    #product-page {
        display: flex;
        flex-direction: row;
        justify-content: space-between;
        padding: 15vh 10vh;
    }

    #product-info {
        max-width: 30vw;
        height: 600px;

        img {
            height: 50px;
            object-fit: fill;
            border-radius: 100%;
            box-shadow: 0px 0px 30px #a0a0a0;
        }

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
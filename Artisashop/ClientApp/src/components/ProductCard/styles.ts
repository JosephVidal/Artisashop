import styled from "styled-components";

export const ProductCardWrapper = styled.div`
    #product-card {
        display: flex;
        flex-direction: column;
        border-radius: var(--elem-radius);
        padding: 20px;
        color: inherit;
        text-decoration: inherit;
        transition: 0.3s;

        img {
            width: 400px;
            height: 400px;
        }

        p {
            font-family: Helvetica;
            margin: 5px 0px;
        }

        :hover {color: var(--artshp-orange);}
    }

    #product-name, #product-price {font-size: 1.5em;}

    #product-serie {font-weight: lighter}
`;
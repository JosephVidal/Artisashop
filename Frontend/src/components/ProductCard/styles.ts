import styled from "styled-components";

export const ProductCardWrapper = styled.div`
    #product-card {
        display: flex;
        flex-direction: column;
        border-radius: var(--elem-radius);
        padding: 20px;
        color: inherit;
        text-decoration: inherit;

        img {
            width: 300px;
            height: 300px;
            object-fit: cover;
            border-radius: var(--elem-radius);
            transition: var(--artshp-trans);
        }

        p {
            font-family: Helvetica;
            margin: 5px 0px;
            transition: var(--artshp-trans);
        }

        :hover {color: var(--artshp-orange);}
    }

    #product-name, #product-price {font-size: 1.5em;}

    #product-serie {font-weight: lighter}

    #line {
        display: flex;
        flex-direction: row;

        span {margin: auto 5px;}
    }

    @media (max-width: 930px) {
        #product-card {
            img {
                width: 140px;
                height: 140px;
            }

            p {font-size: 1em;}
        }
    }
`;
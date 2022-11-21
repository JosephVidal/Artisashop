import styled from "styled-components";

export const CraftsmanresultCardWrapper = styled.div`
    #craftsman-result-card {
        display: flex;
        flex-direction: column;
        border-radius: var(--elem-radius);
        padding: 20px;
        color: inherit;
        text-decoration: inherit;
        transition: 0.3s;

        img {
            width: 300px;
            height: 300px;
            object-fit: cover;
            border-radius: var(--elem-radius);
        }

        p {
            font-family: Helvetica;
            margin: 5px 0px;
        }

        :hover {color: var(--artshp-orange);}
    }

    #craftsman-name {font-size: 1.5em;}

    #craftsman-job {font-weight: lighter}

    @media (max-width: 930px) {
        #craftsman-result-card {
            img {
                height: 150px;
                width: 150px;
            }
        }
    }
`;
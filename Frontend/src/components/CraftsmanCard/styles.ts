import styled from "styled-components";

export const CraftsmanCardWrapper = styled.div`
    a {
        text-decoration: none;
        color: var(--artshp-dark-blue);
    }

    #card {
        background-color: white;
        border-radius: var(--elem-radius);
        padding: 20px;
        margin: 10px;
        width: 500px;

        p {
            font-family: Helvetica;
            margin: 5px;
        }
    }

    #card-header {
        display: flex;
        flex-direction: row;
        justify-content: space-between;
        text-align: right;
        margin-bottom: 40px;

        img {
            height: 90px;
            width: 90px;
            object-fit: cover;
            border-radius: 100%;
        }
    }

    #craftsman-name {font-size: 1.5em;}

    #craftsman-job {
        color: var(--artshp-orange);
        font-weight: lighter;
        font-size: 1.2em;
    }

    #craftsman-description {
        font-size: 1.5em;
        font-weight: lighter;
    }
`;
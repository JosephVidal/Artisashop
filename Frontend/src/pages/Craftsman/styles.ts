import styled from "styled-components";

export const ProductsList = styled.section`
    display: grid;
    grid-template-columns: repeat(2, 1fr);
    grid-gap: 10px;
    grid-auto-rows: minmax(100px, auto);
`;

export const Craftsman = styled.div`
    display: flex;
    flex-direction: row;

    img {
        border-radius: 50%;
        object-fit: cover;
        margin: auto 30px auto 0;
        height: 120px;
    }

    .chat-button {
        background-color: var(--artshp-blue);
        border: 0px;
        border-radius: 50%;
        font-size: 1em;
        margin: auto;
        margin-left: 5px;
        padding: 5px 7px;

        :hover {background-color: var(--artshp-orange);}
    }

    #craftsman-name-section {
        display: flex;
        flex-direction: row;
    }
`;

export const Wrapper = styled.div`
    display: flex;
    flex-direction: row;
    flex-wrap: wrap;
    color: var(--artshp-dark-blue);

    h1 {font-size: 3em;}

    section {
        min-height: 100vh;
        width: 50vw;
        padding: 30px;
        transition: var(--artshp-trans);
    }

    #craftsman {margin: 40px 0;}

    #job, h1 {margin: 0;}

    #bio, #job {font-size: 1.7em;}

    #bio {margin-top: 15vh;}

    @media (max-width: 1440px) {
        flex-direction: column;

        section {width: 100vw;}
    }
`;
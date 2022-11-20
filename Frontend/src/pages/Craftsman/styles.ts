import styled from "styled-components";

export const ProductsList = styled.section`
    display: grid;
    grid-template-columns: repeat(2, 1fr);
    grid-gap: 10px;
    grid-auto-rows: minmax(100px, auto);
`;

export const Wrapper = styled.div`
    display: flex;
    flex-direction: row;
    color: var(--artshp-dark-blue);

    h1 {font-size: 3em;}

    section {
        min-height: 100vh;
        width: 50vw;
        padding: 30px;
    }

    #craftsman {margin: 40px 0;}

    #job, h1 {margin: 0;}

    #bio, #job {font-size: 1.7em;}

    #bio {margin-top: 15vh;}
`;
import styled from "styled-components";
// import { colors } from "globals/styles";

export const FooterWrapper = styled.div`
footer {
    color: var(--bs-light);
    font-family: Helvetica;
    font-weight: lighter;
    text-align: center;
    background-color: #2F3B4B;

    a {
        color: var(--bs-light);
        text-decoration: none;

        &:hover {color: var(--bs-secondary);}
    }

    /* label {background-image: image-url("../../img/SocialNetwork/send.svg");} */
}

.newsletter {
    width: 30vw;
    padding: 5px;
    border: 0px;

    &::placeholder {color: var(--artshp-dark-blue);}
}

#up {
    padding: 10px;
    background-color: #3A4B62;
    text-align: center;
    font-weight: lighter;
}

#newsletter {
    margin: 0 40px;
    padding: 55px;
    border-bottom: solid 1px var(--bs-white);

    input, ::placeholder {
        border-radius: var(--elem-radius);
        color: #2F3B4B;
    }
}

#foot-content {
    display: flex;
    justify-content: space-around;
    padding: 40px 20vw;

    h3 {
        font-family: "Helvetica Neue";
        font-weight: lighter;
        font-size: large;
        padding-bottom: 10px;
        border-bottom: solid 1px var(--bs-white);
    }

    div {
        display: flex;
        flex-direction: column;
        text-align: left;
    }
}

#links {
    display: flex;
    justify-content: space-between;
    padding: 20px;
    background-color: var(--bs-dark);
}

#social {
    display: flex;
    width: 7vw;
    justify-content: space-between;

    svg:hover {cursor: pointer;}

    path, circle {
        fill: var(--bs-white);
        transition: 0.3s;
    }
}

#linkedin {fill: #0e76a8;}
#facebook {fill: #3b5998;}
.instagram {fill: #C13584;}
`;
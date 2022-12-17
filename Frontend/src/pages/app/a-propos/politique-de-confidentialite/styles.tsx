import styled from "styled-components";

export const Container = styled.div`
width: 80%;
margin-left: auto;
margin-right: auto;
margin-bottom: 50px;
padding: 0 10px;
color: black;

@media only screen and (max-width:880px) {
    width: 90%;
}
@media only screen and (max-width:500px) {
    width: 100%;
}
`;

import styled from "styled-components";

export const DateWrapper = styled.div`
  width: 320px;
  height: 100px;
  display: flex;
  flex-direction: column;
  justify-content: space-evenly;
  font-size: 20px;

  & > div {
    display: flex;
    justify-content: space-between;

    & > div {
      width: 200px;
    }
  }
`;

export const TranslationText = styled.div``;

export const DateFormated = styled.div``;

export const DateText = styled.div``;

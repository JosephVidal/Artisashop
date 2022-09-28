import styled from "styled-components";

export const DurationWrapper = styled.div`
  width: 100%;
  margin: 12px 0 30px;
  display: flex;
  flex-direction: row;
  align-items: center;
  justify-content: center;
`;

interface TextProps {
  isError: boolean;
}

export const TextLeft = styled.div<TextProps>`
  text-align: left;
  font-size: 40px;
  margin-right: 20px;
  flex: 1;

  margin-bottom: ${(props) => (props.isError ? "20px" : "0")};
`;

export const TextRight = styled.div<TextProps>`
  width: 44px;
  text-align: right;
  margin-left: 15px;
  align-self: flex-end;

  margin-bottom: ${(props) => (props.isError ? "20px" : "0")};
`;

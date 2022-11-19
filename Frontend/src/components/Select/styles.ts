import styled from "styled-components";

interface SelectWrapperProps {
  visible: boolean;
}

export const SelectWrapper = styled.div<SelectWrapperProps>`
  width: 100%;
  display: ${(props) => (props.visible ? "inline-block" : "none")};

  & .p-dropdown {
    display: flex;
    transition: background-color 0.2s, color 0.2s, border-color 0.2s,
    box-shadow 0.2s;
    border-radius: 5px;
  }
  .p-dropdown .p-dropdown-trigger {
    background: transparent;
    color: rgba(255, 255, 255, 0.6);
    width: 2.357rem;
    border-top-right-radius: 5px;
    border-bottom-right-radius: 5px;
  }
`;

import styled from "styled-components";
import { colors } from "globals/styles";

interface PlayersProps {
  colors: string;
}

interface TableProps {
  going: number;
}

export const GameTableWrapper = styled.div<TableProps>`
  flex: 1;
  overflow: hidden;
  width: 100%;

  & .p-scrollpanel-content > .p-datatable > .p-datatable-wrapper {
    height: 65vh;

    table {
      tbody {
        background-color: ${colors.surfaceD};
      }

      .p-datatable-thead {
        border-bottom: 4px solid ${colors.surfaceD};
      }

      .p-datatable-tbody {
        tbody {
          background-color: ${colors.surfaceD};
        }

        & > tr:nth-child(${(props) => props.going + 1}) {
          z-index: 1;
          background-color: ${colors.surfaceD};
          font-size: 70px;
          transform: scale(101%);
          box-shadow: rgba(0, 0, 0, 0.09) 0 2px 1px,
            rgba(0, 0, 0, 0.09) 0 4px 2px, rgba(0, 0, 0, 0.09) 0 8px 4px,
            rgba(0, 0, 0, 0.09) 0 16px 8px, rgba(0, 0, 0, 0.09) 0 32px 16px;
          td {
            font-size: calc(24px / 1.04);
          }
        }

        & > tr > td {
          height: 70px;
          padding: 10px 15px;
          white-space: nowrap;
        }
      }
    }
  }
`;

export const IndexWrapper = styled.div`
  width: 20px;
`;

export const BeginTimeWrapper = styled.div`
  width: 120px;
`;

export const CreateGameWrapper = styled.div`
  display: flex;
  justify-content: space-between;
  align-items: center;

  svg {
    font-size: 33px;
  }
`;

export const PlayersWrapper = styled.div`
  margin: auto;
  width: 240px;
  text-align: center;
  height: calc(100% + 4px);
  display: flex;
  flex-direction: column;
  justify-content: space-between;
  align-items: center;
`;

export const PlayersNumber = styled.span`
  font-size: 18px;
`;

export const PlayersSquareWrapper = styled.div`
  width: 100%;
  display: flex;
  align-items: center;
  justify-content: center;
`;

export const PlayersSquare = styled.span<PlayersProps>`
  max-width: 23px;
  min-width: 10px;
  height: 23px;
  border-radius: 2px;
  margin-right: 2px;
  background-color: ${(props) => props.colors};
  flex: 1;

  &:last-child {
    margin-right: 0;
  }
`;

export const StatusWrapper = styled.div`
  width: 200px;
  display: flex;
  flex-flow: row nowrap;
`;

export const Status = styled.span``;

export const TimeLeftWrapper = styled.div`
  display: flex;
  justify-content: center;
  align-items: center;
`;

export const Separator = styled.span`
  margin: 0 20px;
`;

export const TimeLeft = styled.span`
  white-space: nowrap;
  font-weight: bolder;
`;

export const DurationWrapper = styled.div`
  width: 200px;
`;

export const EndTimeWrapper = styled.div`
  width: 95%;
  display: flex;
  justify-content: space-between;
`;

export const DeleteGameWrapper = styled.div`
  width: 28px;
  & > svg {
    font-size: 28px;
    margin-bottom: 2px;
    vertical-align: bottom;

    &:hover {
      color: ${colors.red};
    }
  }
`;

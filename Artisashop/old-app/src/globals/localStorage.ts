import _ from "lodash/fp";

export const saveItem = (message: string) => {
  const logIndexes = localStorage.getItem("logIndexes");
  const logIndexesArray = _.split(",", logIndexes);
  const lastIndex = _.last(logIndexesArray);

  if (findItem(message, _.toInteger(lastIndex)) !== -1) return false;

  logIndexesArray.push(
    logIndexes !== null ? _.toString(_.toInteger(lastIndex) + 1) : "0"
  );
  const arrayToString = _.toString(logIndexesArray);

  localStorage.setItem(
    "logIndexes",
    arrayToString[0] === "," ? arrayToString.slice(1) : arrayToString
  );
  localStorage.setItem(`log${_.last(logIndexesArray) || "0"}`, message);

  return true;
};

export const findItem = (
  message: string,
  last: number,
  index: number = 0
): number => {
  const item = localStorage.getItem(`log${_.toString(index)}`);

  if (item && item === message) return index;

  if (index === last) return -1;

  return findItem(message, last, index + 1);
};

export const deleteItem = (message: string | undefined) => {
  if (message) {
    const last = _.last(_.split(",", localStorage.getItem("logIndexes")));
    const log = _.toString(findItem(message, _.toInteger(last)));

    if (log !== "-1") {
      const logIndexes1 = _.split(",", localStorage.getItem("logIndexes"));
      localStorage.removeItem(`log${log}`);
      localStorage.setItem(
        "logIndexes",
        _.toString(_.filter((o) => o !== log, logIndexes1))
      );
    }
  }
};

export const getLogs = () => {
  const logIndexes = _.split(",", localStorage.getItem("logIndexes"));

  return _.map(
    (index) => localStorage.getItem(`log${_.toString(index)}`),
    logIndexes
  );
};

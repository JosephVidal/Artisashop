import { useMemo } from "react";
import { Configuration, ConfigurationParameters } from "api";
import { REACT_APP_API_URL } from "conf";
import tokenAtom from "states/atoms/token";
import { useAtom } from "jotai";

/**
 * Returns a configured instance of the API.
 * @param Api the type of the API to return
 * @example `const api = useApi(AccountApi)`
 */
const useApi = <T,>(Api: { new(config: Configuration): T; }): T => {
  const [token] = useAtom(tokenAtom);

  const config = useMemo(() => {
    const base: ConfigurationParameters = {
      basePath: REACT_APP_API_URL,
      headers: {
        "Content-Type": "application/json",
        // "Authorization": `Bearer ${localStorage.getItem("token") || ""}`,
      }
    }
    return token
      ? new Configuration({ ...base, accessToken: token })
      : new Configuration({ ...base });
  }
    , [token])
  return useMemo(() => new Api(config), [Api, config]);
}

export default useApi;

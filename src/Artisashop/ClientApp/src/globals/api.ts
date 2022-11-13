import axios, { AxiosResponse } from "axios";
import { ResultContent } from "./result";

axios.defaults.baseURL = process.env.REACT_APP_HERMES_BASE_PATH;

export const getRequest = <T>(
  url: string
): Promise<AxiosResponse<ResultContent<T>>> => axios.get(url);

export const putRequest = <T>(
  url: string,
  data: Record<string, unknown>
): Promise<AxiosResponse<ResultContent<T>>> => axios.put(url, data);

export const postRequest = <T>(
  url: string,
  data?: Record<string, unknown>
): Promise<AxiosResponse<ResultContent<T>>> => axios.post(url, data);

export const deleteRequest = <T>(
  url: string
): Promise<AxiosResponse<ResultContent<T>>> => axios.delete(url);

export const EducationAPI = axios.create({
  baseURL: "https://data.education.gouv.fr/api",
});

export const CalendarAPI = axios.create({
  baseURL: "https://calendrier.api.gouv.fr",
});

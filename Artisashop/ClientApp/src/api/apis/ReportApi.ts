/* tslint:disable */
/* eslint-disable */
/**
 * API Artichaut
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: v1
 * 
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */


import * as runtime from '../runtime';
import type {
  ProblemDetails,
  Report,
} from '../models';
import {
    ProblemDetailsFromJSON,
    ProblemDetailsToJSON,
    ReportFromJSON,
    ReportToJSON,
} from '../models';

export interface ApiReportsIdDeleteRequest {
    id: number;
}

export interface ApiReportsIdGetRequest {
    id: number;
}

export interface ApiReportsIdPutRequest {
    id: number;
    report?: Report;
}

export interface ApiReportsIdResolvePostRequest {
    id: number;
}

export interface ApiReportsPostRequest {
    report?: Report;
}

/**
 * 
 */
export class ReportApi extends runtime.BaseAPI {

    /**
     */
    async apiReportsGetRaw(initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<Array<Report>>> {
        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        if (this.configuration && this.configuration.apiKey) {
            headerParameters["Authorization"] = this.configuration.apiKey("Authorization"); // Bearer authentication
        }

        const response = await this.request({
            path: `/api/reports`,
            method: 'GET',
            headers: headerParameters,
            query: queryParameters,
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => jsonValue.map(ReportFromJSON));
    }

    /**
     */
    async apiReportsGet(initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<Array<Report>> {
        const response = await this.apiReportsGetRaw(initOverrides);
        return await response.value();
    }

    /**
     */
    async apiReportsIdDeleteRaw(requestParameters: ApiReportsIdDeleteRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<void>> {
        if (requestParameters.id === null || requestParameters.id === undefined) {
            throw new runtime.RequiredError('id','Required parameter requestParameters.id was null or undefined when calling apiReportsIdDelete.');
        }

        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        if (this.configuration && this.configuration.apiKey) {
            headerParameters["Authorization"] = this.configuration.apiKey("Authorization"); // Bearer authentication
        }

        const response = await this.request({
            path: `/api/reports/{id}`.replace(`{${"id"}}`, encodeURIComponent(String(requestParameters.id))),
            method: 'DELETE',
            headers: headerParameters,
            query: queryParameters,
        }, initOverrides);

        return new runtime.VoidApiResponse(response);
    }

    /**
     */
    async apiReportsIdDelete(requestParameters: ApiReportsIdDeleteRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<void> {
        await this.apiReportsIdDeleteRaw(requestParameters, initOverrides);
    }

    /**
     */
    async apiReportsIdGetRaw(requestParameters: ApiReportsIdGetRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<Report>> {
        if (requestParameters.id === null || requestParameters.id === undefined) {
            throw new runtime.RequiredError('id','Required parameter requestParameters.id was null or undefined when calling apiReportsIdGet.');
        }

        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        if (this.configuration && this.configuration.apiKey) {
            headerParameters["Authorization"] = this.configuration.apiKey("Authorization"); // Bearer authentication
        }

        const response = await this.request({
            path: `/api/reports/{id}`.replace(`{${"id"}}`, encodeURIComponent(String(requestParameters.id))),
            method: 'GET',
            headers: headerParameters,
            query: queryParameters,
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => ReportFromJSON(jsonValue));
    }

    /**
     */
    async apiReportsIdGet(requestParameters: ApiReportsIdGetRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<Report> {
        const response = await this.apiReportsIdGetRaw(requestParameters, initOverrides);
        return await response.value();
    }

    /**
     */
    async apiReportsIdPutRaw(requestParameters: ApiReportsIdPutRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<void>> {
        if (requestParameters.id === null || requestParameters.id === undefined) {
            throw new runtime.RequiredError('id','Required parameter requestParameters.id was null or undefined when calling apiReportsIdPut.');
        }

        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        headerParameters['Content-Type'] = 'application/json';

        if (this.configuration && this.configuration.apiKey) {
            headerParameters["Authorization"] = this.configuration.apiKey("Authorization"); // Bearer authentication
        }

        const response = await this.request({
            path: `/api/reports/{id}`.replace(`{${"id"}}`, encodeURIComponent(String(requestParameters.id))),
            method: 'PUT',
            headers: headerParameters,
            query: queryParameters,
            body: ReportToJSON(requestParameters.report),
        }, initOverrides);

        return new runtime.VoidApiResponse(response);
    }

    /**
     */
    async apiReportsIdPut(requestParameters: ApiReportsIdPutRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<void> {
        await this.apiReportsIdPutRaw(requestParameters, initOverrides);
    }

    /**
     */
    async apiReportsIdResolvePostRaw(requestParameters: ApiReportsIdResolvePostRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<void>> {
        if (requestParameters.id === null || requestParameters.id === undefined) {
            throw new runtime.RequiredError('id','Required parameter requestParameters.id was null or undefined when calling apiReportsIdResolvePost.');
        }

        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        if (this.configuration && this.configuration.apiKey) {
            headerParameters["Authorization"] = this.configuration.apiKey("Authorization"); // Bearer authentication
        }

        const response = await this.request({
            path: `/api/reports/{id}/resolve`.replace(`{${"id"}}`, encodeURIComponent(String(requestParameters.id))),
            method: 'POST',
            headers: headerParameters,
            query: queryParameters,
        }, initOverrides);

        return new runtime.VoidApiResponse(response);
    }

    /**
     */
    async apiReportsIdResolvePost(requestParameters: ApiReportsIdResolvePostRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<void> {
        await this.apiReportsIdResolvePostRaw(requestParameters, initOverrides);
    }

    /**
     */
    async apiReportsPostRaw(requestParameters: ApiReportsPostRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<Report>> {
        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        headerParameters['Content-Type'] = 'application/json';

        if (this.configuration && this.configuration.apiKey) {
            headerParameters["Authorization"] = this.configuration.apiKey("Authorization"); // Bearer authentication
        }

        const response = await this.request({
            path: `/api/reports`,
            method: 'POST',
            headers: headerParameters,
            query: queryParameters,
            body: ReportToJSON(requestParameters.report),
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => ReportFromJSON(jsonValue));
    }

    /**
     */
    async apiReportsPost(requestParameters: ApiReportsPostRequest = {}, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<Report> {
        const response = await this.apiReportsPostRaw(requestParameters, initOverrides);
        return await response.value();
    }

}

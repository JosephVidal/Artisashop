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


/**
 * 
 * @export
 */
export const State = {
    NUMBER_0: 0,
    NUMBER_1: 1,
    NUMBER_2: 2,
    NUMBER_3: 3,
    NUMBER_4: 4,
    NUMBER_5: 5,
    NUMBER_6: 6
} as const;
export type State = typeof State[keyof typeof State];


export function StateFromJSON(json: any): State {
    return StateFromJSONTyped(json, false);
}

export function StateFromJSONTyped(json: any, ignoreDiscriminator: boolean): State {
    return json as State;
}

export function StateToJSON(value?: State | null): any {
    return value as any;
}


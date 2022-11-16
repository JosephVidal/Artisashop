/* tslint:disable */
/* eslint-disable */
/**
 * API Artisashop
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: v1
 * 
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */

import { exists, mapValues } from '../runtime';
/**
 * 
 * @export
 * @interface GPSCoord
 */
export interface GPSCoord {
    /**
     * 
     * @type {number}
     * @memberof GPSCoord
     */
    lat?: number;
    /**
     * 
     * @type {number}
     * @memberof GPSCoord
     */
    lng?: number;
}

/**
 * Check if a given object implements the GPSCoord interface.
 */
export function instanceOfGPSCoord(value: object): boolean {
    let isInstance = true;

    return isInstance;
}

export function GPSCoordFromJSON(json: any): GPSCoord {
    return GPSCoordFromJSONTyped(json, false);
}

export function GPSCoordFromJSONTyped(json: any, ignoreDiscriminator: boolean): GPSCoord {
    if ((json === undefined) || (json === null)) {
        return json;
    }
    return {
        
        'lat': !exists(json, 'lat') ? undefined : json['lat'],
        'lng': !exists(json, 'lng') ? undefined : json['lng'],
    };
}

export function GPSCoordToJSON(value?: GPSCoord | null): any {
    if (value === undefined) {
        return undefined;
    }
    if (value === null) {
        return null;
    }
    return {
        
        'lat': value.lat,
        'lng': value.lng,
    };
}


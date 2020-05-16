import { SectionDTO } from './section.model';

export class GraveOwnerDTO {
    Id: number;
    SubId: string;
    GraveReferenceCode: string;
    GraveRow: number;
    GraveDepth: number;
    GraveSize: string;
    GraveLocation: string;
    GraveHeadStone: boolean;
    GraveOwnerName: string;
    GraveOwnerAddress: string;
    Remarks: string;
    Section: SectionDTO;
}

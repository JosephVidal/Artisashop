import React, { FC, useEffect, useState } from "react";
import { ToastHandler } from "components/Toaster";
import Content from "components/Content";
import { useTranslation } from "react-i18next";
import { retrieveOpeningHours } from "openingHours";
import { Calendar } from "models/openingHours";
import { DaysWrapper } from "pages/Parameters/OpeningHours/styles";
import { TabPanel, TabView } from "primereact/tabview";
import OpeningHoursForm from "pages/Parameters/OpeningHours/components/OpeningHoursForm";

interface Props {
  toastHandler: ToastHandler;
}

const OpeningHours: FC<Props> = ({ toastHandler }) => {
  const [openingsHours, setOpeningsHours] = useState<Calendar>({
    schoolingDays: [],
    schoolVacation: [],
    holiday: {
      id: "",
      day: "HOLIDAY",
      closed: true,
    },
  });
  const [loading, setLoading] = useState<boolean>(true);

  const { t } = useTranslation();

  useEffect(() => {
    retrieveOpeningHours(toastHandler, openingsHours, setOpeningsHours).then(
      (calendar) => {
        if (calendar.schoolingDays.length > 0) setLoading(false);
      }
    );
  }, []);

  return (
    <Content title={t("parameters.opening-hours.title")} loading={loading}>
      <DaysWrapper>
        <TabView>
          <TabPanel header={t("parameters.opening-hours.schooling-days")}>
            <OpeningHoursForm
              toastHandler={toastHandler}
              period="schooling-days"
              openingHours={openingsHours.schoolingDays}
              setOpeningHours={setOpeningsHours}
            />
          </TabPanel>
          <TabPanel header={t("parameters.opening-hours.school-vacations")}>
            <OpeningHoursForm
              period="school-vacation"
              toastHandler={toastHandler}
              openingHours={openingsHours.schoolVacation}
              setOpeningHours={setOpeningsHours}
            />
          </TabPanel>
          <TabPanel header={t("parameters.opening-hours.holidays")}>
            <OpeningHoursForm
              period="holiday"
              toastHandler={toastHandler}
              openingHours={openingsHours.holiday}
              setOpeningHours={setOpeningsHours}
            />
          </TabPanel>
        </TabView>
      </DaysWrapper>
    </Content>
  );
};

export default OpeningHours;
